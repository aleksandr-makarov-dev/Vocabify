import { UseMutationOptions, useMutation } from "@tanstack/react-query";
import { AxiosError } from "axios";
import { SetFormSchema } from "../types";
import { ObjectId } from "@/types";
import axios from "@/lib/axios";

const updateSet = async (values: SetFormSchema): Promise<ObjectId> => {
  const response = await axios.post<ObjectId>("/sets", values);
  return response.data;
};

type UseUpdateSetMutation = UseMutationOptions<
  ObjectId,
  AxiosError,
  SetFormSchema,
  unknown[]
>;

type UseUpdateSetOptions = Omit<
  UseUpdateSetMutation,
  "mutationKey" | "mutationFn"
>;

export const useUpdateSet = (options?: UseUpdateSetOptions) => {
  return useMutation<ObjectId, AxiosError, SetFormSchema, unknown[]>({
    mutationKey: ["sets", "update"],
    mutationFn: async (values) => {
      return await updateSet(values);
    },
    ...options,
  });
};
