import { UseMutationOptions, useMutation } from "@tanstack/react-query";
import { AxiosError } from "axios";
import { CreateSetSchema } from "../types";
import { ObjectId } from "@/types";
import axios from "@/lib/axios";

const createSet = async (values: CreateSetSchema): Promise<ObjectId> => {
  const response = await axios.post<ObjectId>("/sets", values);
  return response.data;
};

type UseCreateSetMutation = UseMutationOptions<
  ObjectId,
  AxiosError,
  CreateSetSchema,
  unknown[]
>;

type UseCreateSetOptions = Omit<
  UseCreateSetMutation,
  "mutationKey" | "mutationFn"
>;

export const useCreateSet = (options?: UseCreateSetOptions) => {
  return useMutation<ObjectId, AxiosError, CreateSetSchema, unknown[]>({
    mutationKey: ["sets", "create"],
    mutationFn: async (values) => {
      return await createSet(values);
    },
    ...options,
  });
};
