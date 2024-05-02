import { SetWithTerms } from "@/features/sets/types";
import { UseQueryOptions, useQuery } from "@tanstack/react-query";
import { AxiosError } from "axios";
import axios from "@/lib/axios";

const importSet = async (values: UseImportSetParams) => {
  const response = await axios.get<SetWithTerms>(
    `/sets/import?url=${values.url}`
  );
  return response.data;
};

type UseImportSetParams = {
  url: string;
};

type UseImportSetQuery = UseQueryOptions<
  SetWithTerms,
  AxiosError,
  SetWithTerms,
  unknown[]
>;

type UseImportSetOptions = Omit<UseImportSetQuery, "queryKey" | "queryFn">;

export const useImportSet = (
  values: UseImportSetParams,
  options?: UseImportSetOptions
) => {
  return useQuery<SetWithTerms, AxiosError, SetWithTerms, unknown[]>({
    queryKey: ["sets", "import", values],
    queryFn: async () => {
      return await importSet(values);
    },
    ...options,
  });
};
