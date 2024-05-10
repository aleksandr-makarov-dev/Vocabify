import { Button } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { zodResolver } from "@hookform/resolvers/zod";
import { Import } from "lucide-react";
import { FC } from "react";
import { useForm } from "react-hook-form";
import { SetImportFormSchema } from "../types";
import { setImportFormSchema } from "../schemas";
interface SetImportFormProps {
  onSubmit: (values: SetImportFormSchema) => void;
  isLoading?: boolean;
}

const SetImportForm: FC<SetImportFormProps> = ({ onSubmit, isLoading }) => {
  const form = useForm<SetImportFormSchema>({
    resolver: zodResolver(setImportFormSchema),
    defaultValues: {
      url: "",
    },
  });

  return (
    <Form {...form}>
      <form
        className="flex flex-col gap-3 sm:flex-row"
        onSubmit={form.handleSubmit(onSubmit)}
      >
        <FormField
          control={form.control}
          name="url"
          render={({ field }) => (
            <FormItem className="w-full">
              <FormControl>
                <Input placeholder="Enter an url" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button loading={isLoading} icon={<Import className="w-5 h-5" />}>
          Import
        </Button>
      </form>
    </Form>
  );
};

export default SetImportForm;
