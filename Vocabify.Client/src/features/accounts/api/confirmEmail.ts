import { Message, ProblemDetails } from "@/types";
import { ConfirmEmailSchema } from "../types";
import axios from "@/lib/axios";
import { AxiosError } from "axios";
import { UseMutationOptions, useMutation } from "@tanstack/react-query";

const confirmEmail = async (values: ConfirmEmailSchema): Promise<Message> => {
  const response = await axios.post<Message>("/accounts/confirm-email", values);
  return response.data;
};

type UseConfirmEmailMutation = UseMutationOptions<
  Message,
  AxiosError<ProblemDetails>,
  ConfirmEmailSchema,
  unknown[]
>;

type UseConfirmEmailOptions = Omit<
  UseConfirmEmailMutation,
  "mutationKey" | "mutationFn"
>;

export const useConfirmEmail = (options?: UseConfirmEmailOptions) => {
  return useMutation<
    Message,
    AxiosError<ProblemDetails>,
    ConfirmEmailSchema,
    unknown[]
  >({
    mutationKey: ["accounts", "login"],
    mutationFn: async (values) => {
      return await confirmEmail(values);
    },
    ...options,
  });
};
