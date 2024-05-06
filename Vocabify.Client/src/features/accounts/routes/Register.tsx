import Card from "@/components/common/Card";
import { FC } from "react";
import RegisterForm from "../components/RegisterForm";
import { useRegister } from "../api/register";
import { RegisterSchema } from "../types";
import FormAlert from "@/components/common/FormAlert";
import { UseFormReset } from "react-hook-form";

export const Register: FC = () => {
  const { mutate, isPending, isError, error, isSuccess, data } = useRegister();

  const onSubmit = (
    values: RegisterSchema,
    reset: UseFormReset<RegisterSchema>
  ) => {
    mutate(values, {
      onSuccess: () => reset(),
    });
  };

  return (
    <Card className="space-y-5 p-5 max-w-md w-full">
      <h5 className="text-center text-2xl font-medium">Registration</h5>
      <FormAlert
        isError={isError}
        error={
          error?.response?.data ?? {
            title: "Error",
            status: 0,
            detail: error?.message,
          }
        }
        isSuccess={isSuccess}
        success={data}
      />
      <RegisterForm onSubmit={onSubmit} isLoading={isPending} />
      <p className="text-center text-sm">
        Already have an account?{" "}
        <a
          href="/accounts/login"
          className="font-medium underline-offset-2 underline"
        >
          Login
        </a>
      </p>
    </Card>
  );
};
