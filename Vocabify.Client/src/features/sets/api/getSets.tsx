import { Set } from "@/features/sets/types";
import { UseQueryOptions, useQuery } from "@tanstack/react-query";
import { mockSets } from "../constants";
import { AxiosError } from "axios";

const getSets = async () => {
  // const response = await axios.get<Set[]>("/sets");
  // return response.data;

  return mockSets;
};

type UseSetsQuery = UseQueryOptions<Set[], AxiosError, Set[], unknown[]>;

type UseSetsOptions = Omit<UseSetsQuery, "queryKey" | "queryFn">;

export const useSets = (options?: UseSetsOptions) => {
  return useQuery<Set[], AxiosError, Set[], unknown[]>({
    queryKey: ["sets"],
    queryFn: async () => {
      return await getSets();
    },
    ...options,
  });
};
