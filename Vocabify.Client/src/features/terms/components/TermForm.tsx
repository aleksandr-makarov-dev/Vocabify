import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
} from "@/components/ui/form";
import { FC } from "react";
import { TermFormSchema } from "../types";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { termFormSchema } from "../schemas";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import SoundButton from "@/components/common/SoundButton";

interface TermFormProps {
  onSubmit: (values: TermFormSchema) => void;
  term?: TermFormSchema;
}

const TermForm: FC<TermFormProps> = ({ term, onSubmit }) => {
  const form = useForm<TermFormSchema>({
    resolver: zodResolver(termFormSchema),
    defaultValues: {
      text: "",
      definition: "",
      setId: "",
    },
    values: term,
  });

  return (
    <Form {...form}>
      <form className="space-y-3" onSubmit={form.handleSubmit(onSubmit)}>
        <div className="flex space-x-3 items-center">
          <div className="w-full space-y-3">
            <FormField
              control={form.control}
              name="text"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Text</FormLabel>
                  <FormControl>
                    <Input placeholder="Enter a text" {...field} />
                  </FormControl>
                </FormItem>
              )}
            />
            <FormField
              control={form.control}
              name="definition"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Definition</FormLabel>
                  <FormControl>
                    <Input placeholder="Enter a definition" {...field} />
                  </FormControl>
                </FormItem>
              )}
            />
          </div>
          <img
            src="placeholder.png"
            className="w-36 h-36 object-center object-cover rounded-md"
          />
        </div>
        <div className="gap-x-3 w-full flex">
          <Button>Save</Button>
          <Button type="button" variant="outline">
            Cancel
          </Button>
          <SoundButton />
          <div className="grow flex justify-end">
            <Button type="button" className="self-end" variant="destructive">
              Delete
            </Button>
          </div>
        </div>
      </form>
    </Form>
  );
};

export default TermForm;
