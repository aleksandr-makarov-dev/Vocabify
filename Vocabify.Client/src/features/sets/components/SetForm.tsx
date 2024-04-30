import { FC } from "react";
import { SetFormSchema } from "../types";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { setFormSchema } from "../schemas";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";

interface SetFormProps {
  set?: SetFormSchema;
  onSubmit: (values: SetFormSchema) => void;
}

const SetForm: FC<SetFormProps> = ({ set, onSubmit }) => {
  const form = useForm<SetFormSchema>({
    resolver: zodResolver(setFormSchema),
    defaultValues: {
      title: "",
      textLang: "FI",
      definitionLang: "EN",
    },
    values: set,
  });

  return (
    <Form {...form}>
      <form className="space-y-3" onSubmit={form.handleSubmit(onSubmit)}>
        <FormField
          control={form.control}
          name="title"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Title</FormLabel>
              <FormControl>
                <Input placeholder="Enter a title" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="description"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Description</FormLabel>
              <FormControl>
                <Input placeholder="Enter a description..." {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <div className="flex flex-col md:grid md:grid-cols-2 space-x-0 md:space-x-3 space-y-3 md:space-y-0">
          <FormField
            control={form.control}
            name="textLang"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Text Language</FormLabel>
                <FormControl>
                  <Input placeholder="Choose text language" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name="definitionLang"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Definition Language</FormLabel>
                <FormControl>
                  <Input placeholder="Choose definition language" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
        </div>
        <div className="space-x-3">
          <Button>Create</Button>
          <Button variant="outline">Cancel</Button>
        </div>
      </form>
    </Form>
  );
};

export default SetForm;
