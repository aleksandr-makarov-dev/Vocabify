import { ProblemDetails } from "@/types";
import axios from "@/lib/axios";
import { AxiosError } from "axios";
import { UseMutationOptions, useMutation } from "@tanstack/react-query";

const Logout = async (): Promise<void> => {
  await axios.delete<void>("/accounts/Logout");
};

type UseLogoutMutation = UseMutationOptions<
  void,
  AxiosError<ProblemDetails>,
  unknown,
  unknown[]
>;

type UseLogoutOptions = Omit<UseLogoutMutation, "mutationKey" | "mutationFn">;

export const useLogout = (options?: UseLogoutOptions) => {
  return useMutation<void, AxiosError<ProblemDetails>, unknown, unknown[]>({
    mutationKey: ["accounts", "logout"],
    mutationFn: async () => {
      await Logout();
    },
    ...options,
  });
};
