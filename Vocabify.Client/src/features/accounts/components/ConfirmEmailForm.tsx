import { Button } from "@/components/ui/button";
import { FormField, FormItem, FormControl, Form } from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { zodResolver } from "@hookform/resolvers/zod";
import { FC } from "react";
import { useForm } from "react-hook-form";
import { confirmEmailSchema } from "../schemas";
import { ConfirmEmailSchema, UserInfo } from "../types";

interface ConfirmEmailProps {
  user: UserInfo;
  isLoading?: boolean;
  onSubmit: (values: ConfirmEmailSchema) => void;
}

const ConfirmEmailForm: FC<ConfirmEmailProps> = ({
  user,
  isLoading,
  onSubmit,
}) => {
  const form = useForm<ConfirmEmailSchema>({
    resolver: zodResolver(confirmEmailSchema),
    defaultValues: {
      email: "",
    },
    values: {
      email: user.email,
    },
  });

  return (
    <Form {...form}>
      <form
        className="flex items-center gap-x-3"
        onSubmit={form.handleSubmit(onSubmit)}
      >
        <p className="text-sm font-medium">{user.roles.join(";")}</p>
        <FormField
          control={form.control}
          name="email"
          render={({ field }) => (
            <FormItem className="w-full">
              <FormControl>
                <Input disabled={isLoading} readOnly {...field} />
              </FormControl>
            </FormItem>
          )}
        />
        <Button loading={isLoading}>Confirm</Button>
      </form>
    </Form>
  );
};

export default ConfirmEmailForm;
