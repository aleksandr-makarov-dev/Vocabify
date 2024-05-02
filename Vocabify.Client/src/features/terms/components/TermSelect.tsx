import {
  FormField,
  FormItem,
  FormLabel,
  FormControl,
} from "@/components/ui/form";
import { RadioGroup, RadioGroupItem } from "@/components/ui/radio-group";
import { PracticeFormSchema } from "@/features/sets/routes/Practice";
import { cn } from "@/lib/utils";
import { FC } from "react";
import { Control } from "react-hook-form";

interface TermSelectProps {
  control: Control<PracticeFormSchema>;
  options: { value: string; isCorrect: boolean }[];
  state: boolean;
}

const TermSelect: FC<TermSelectProps> = ({ options, control, state }) => {
  return (
    <FormField
      control={control}
      name="answer"
      render={({ field }) => (
        <FormItem className="space-y-3">
          <FormLabel className="text-base">Choose matching option:</FormLabel>
          <FormControl>
            <RadioGroup
              onValueChange={field.onChange}
              defaultValue={field.value}
              className="grid-cols-2 gap-3"
            >
              {options.map((option) => (
                <FormItem
                  key={option.value}
                  className="flex items-center space-x-3 space-y-0"
                >
                  <FormLabel
                    className={cn(
                      "font-normal cursor-pointer flex items-center gap-1.5 w-full p-5 rounded-md border border-border hover:bg-muted",
                      {
                        "bg-red-100 border-red-500 hover:bg-red-100":
                          state && !option.isCorrect,
                      },
                      {
                        "bg-green-100 border-green-500 hover:bg-green-100":
                          state && option.isCorrect,
                      }
                    )}
                  >
                    <FormControl>
                      <RadioGroupItem disabled={state} value={option.value} />
                    </FormControl>
                    <span>{option.value}</span>
                  </FormLabel>
                </FormItem>
              ))}
            </RadioGroup>
          </FormControl>
        </FormItem>
      )}
    />
  );
};

export default TermSelect;
