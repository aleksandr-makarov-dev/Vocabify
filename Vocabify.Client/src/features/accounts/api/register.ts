import { Message, ProblemDetails } from "@/types";
import { RegisterSchema } from "../types";
import axios from "@/lib/axios";
import { AxiosError } from "axios";
import { UseMutationOptions, useMutation } from "@tanstack/react-query";

const register = async (values: RegisterSchema): Promise<Message> => {
  const response = await axios.post<Message>("/accounts/register", values);
  return response.data;
};

type UseRegisterMutation = UseMutationOptions<
  Message,
  AxiosError<ProblemDetails>,
  RegisterSchema,
  unknown[]
>;

type UseRegisterOptions = Omit<
  UseRegisterMutation,
  "mutationKey" | "mutationFn"
>;

export const useRegister = (options?: UseRegisterOptions) => {
  return useMutation<
    Message,
    AxiosError<ProblemDetails>,
    RegisterSchema,
    unknown[]
  >({
    mutationKey: ["accounts", "register"],
    mutationFn: async (values) => {
      return await register(values);
    },
    ...options,
  });
};
