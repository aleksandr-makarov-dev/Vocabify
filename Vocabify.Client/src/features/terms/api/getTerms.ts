import { UseQueryOptions, useQuery } from "@tanstack/react-query";
import { Term } from "../types";
import { AxiosError } from "axios";
import axios from "@/lib/axios";

const getTerms = async (values: UseTermsParams) => {
  const response = await axios.get<Term[]>(`/terms?setId=${values.setId}`);
  return response.data;
};

type UseTermsParams = {
  setId: string;
};

type UseTermsQuery = UseQueryOptions<Term[], AxiosError, Term[], unknown[]>;

type UseTermsOptions = Omit<UseTermsQuery, "queryKey" | "queryFn">;

export const useTerms = (values: UseTermsParams, options?: UseTermsOptions) => {
  return useQuery<Term[], AxiosError, Term[], unknown[]>({
    queryKey: ["terms"],
    queryFn: async () => {
      return await getTerms(values);
    },
    ...options,
  });
};
