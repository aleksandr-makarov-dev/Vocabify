import { Message, ProblemDetails } from "@/types";
import { LoginSchema } from "../types";
import axios from "@/lib/axios";
import { AxiosError } from "axios";
import { UseMutationOptions, useMutation } from "@tanstack/react-query";

const login = async (values: LoginSchema): Promise<Message> => {
  const response = await axios.post<Message>("/accounts/login", values);
  return response.data;
};

type UseLoginMutation = UseMutationOptions<
  Message,
  AxiosError<ProblemDetails>,
  LoginSchema,
  unknown[]
>;

type UseLoginOptions = Omit<UseLoginMutation, "mutationKey" | "mutationFn">;

export const useLogin = (options?: UseLoginOptions) => {
  return useMutation<
    Message,
    AxiosError<ProblemDetails>,
    LoginSchema,
    unknown[]
  >({
    mutationKey: ["accounts", "login"],
    mutationFn: async (values) => {
      return await login(values);
    },
    ...options,
  });
};
