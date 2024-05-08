import { FC } from "react";
import { UseFormReset, useForm } from "react-hook-form";
import { LoginSchema, RegisterSchema } from "../types";
import { zodResolver } from "@hookform/resolvers/zod";
import {
  FormField,
  FormItem,
  FormLabel,
  FormControl,
  FormMessage,
  Form,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { loginSchema } from "../schemas";

interface LoginFormProps {
  onSubmit: (values: RegisterSchema, reset: UseFormReset<LoginSchema>) => void;
  isLoading?: boolean;
}

const LoginForm: FC<LoginFormProps> = ({ onSubmit, isLoading }) => {
  const form = useForm<LoginSchema>({
    resolver: zodResolver(loginSchema),
    defaultValues: {
      email: "",
      password: "",
    },
  });

  return (
    <Form {...form}>
      <form
        className="space-y-3"
        onSubmit={form.handleSubmit((data) => onSubmit(data, form.reset))}
      >
        <FormField
          control={form.control}
          name="email"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Email</FormLabel>
              <FormControl>
                <Input disabled={isLoading} {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="password"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Password</FormLabel>
              <FormControl>
                <Input type="password" disabled={isLoading} {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button className="w-full" loading={isLoading}>
          Login
        </Button>
      </form>
    </Form>
  );
};

export default LoginForm;
