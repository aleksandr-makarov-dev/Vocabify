import Card from "@/components/common/Card";
import { FC } from "react";
import LoginForm from "../components/LoginForm";
import { useLogin } from "../api/login";
import { LoginSchema } from "../types";
import FormAlert from "@/components/common/FormAlert";
import { UseFormReset } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import { useSession } from "../providers/SessionProvider";

export const Login: FC = () => {
  const { login } = useSession();
  const { mutate, isPending, isError, error, isSuccess, data } = useLogin();
  const navigate = useNavigate();

  const onSubmit = (values: LoginSchema, reset: UseFormReset<LoginSchema>) => {
    mutate(values, {
      onSuccess: () => {
        reset();
        login();
        navigate("/library");
      },
      onError: () => {
        reset();
      },
    });
  };

  return (
    <Card className="space-y-5 p-5 max-w-md w-full">
      <h5 className="text-center text-2xl font-medium">Login</h5>
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
      <LoginForm onSubmit={onSubmit} isLoading={isPending} />
      <p className="text-center text-sm">
        Don't have an account?{" "}
        <a
          href="/accounts/register"
          className="font-medium underline-offset-2 underline"
        >
          Register
        </a>
      </p>
    </Card>
  );
};
