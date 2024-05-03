import { Set } from "@/features/sets/types";
import { UseQueryOptions, useQuery } from "@tanstack/react-query";
import { AxiosError } from "axios";
import axios from "@/lib/axios";

const getSets = async (params: UseSetParams) => {
  const response = await axios.get<Set[]>("/sets", {
    params: params,
  });
  return response.data;
};

type UseSetsQuery = UseQueryOptions<Set[], AxiosError, Set[], unknown[]>;

type UseSetsOptions = Omit<UseSetsQuery, "queryKey" | "queryFn">;

type UseSetParams = {
  search?: string | null;
};

export const useSets = (params: UseSetParams, options?: UseSetsOptions) => {
  return useQuery<Set[], AxiosError, Set[], unknown[]>({
    queryKey: ["sets", params],
    queryFn: async () => {
      return await getSets(params);
    },
    ...options,
  });
};
