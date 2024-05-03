import {
  FormField,
  FormItem,
  FormLabel,
  FormControl,
} from "@/components/ui/form";
import { RadioGroup, RadioGroupItem } from "@/components/ui/radio-group";
import {
  PracticeFormSchema,
  QuestionState,
} from "@/features/sets/routes/Practice";
import { cn } from "@/lib/utils";
import { FC } from "react";
import { Control } from "react-hook-form";

interface TermSelectProps {
  control: Control<PracticeFormSchema>;
  options: { value: string; isCorrect: boolean }[];
  state: QuestionState;
}

const TermSelect: FC<TermSelectProps> = ({ options, control, state }) => {
  return (
    <FormField
      control={control}
      name="answer"
      render={({ field }) => {
        const isSuccess = state === "success";
        const isError = state === "error";
        const isSkipped = state === "skip";

        return (
          <FormItem className="space-y-3">
            <FormLabel
              className={cn(
                "text-base",
                isSuccess && "text-green-600",
                isError && "text-red-600"
              )}
            >
              {state === "idle"
                ? "Choose matching option:"
                : isSuccess
                ? "Congratulations, your answer is correct!"
                : isSkipped
                ? "Give this one a try later!"
                : "Not quite, you're still learning!"}
            </FormLabel>
            <FormControl>
              <RadioGroup
                onValueChange={field.onChange}
                defaultValue={field.value}
                className="flex flex-col sm:grid grid-cols-2 gap-3"
              >
                {options.map((option) => (
                  <FormItem
                    key={option.value}
                    className={cn("flex items-center space-x-3 space-y-0")}
                  >
                    <FormLabel
                      className={cn(
                        "font-normal cursor-pointer flex items-center gap-1.5 w-full p-5 rounded-md border border-border hover:bg-muted",
                        state !== "idle" &&
                          (option.isCorrect
                            ? "bg-green-100 border-green-600 hover:bg-green-100"
                            : "bg-red-100 border-red-600 hover:bg-red-100")
                      )}
                    >
                      <FormControl>
                        <RadioGroupItem
                          disabled={state !== "idle"}
                          value={option.value}
                        />
                      </FormControl>
                      <span>{option.value}</span>
                    </FormLabel>
                  </FormItem>
                ))}
              </RadioGroup>
            </FormControl>
          </FormItem>
        );
      }}
    />
  );
};

export default TermSelect;
