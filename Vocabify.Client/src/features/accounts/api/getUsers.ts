import { ProblemDetails } from "@/types";
import axios from "@/lib/axios";
import { AxiosError } from "axios";
import { UseQueryOptions, useQuery } from "@tanstack/react-query";
import { UserInfo } from "../types";

const getUsers = async (): Promise<UserInfo[]> => {
  const response = await axios.get<UserInfo[]>("/accounts");
  return response.data;
};

type UseUsersQuery = UseQueryOptions<
  UserInfo[],
  AxiosError<ProblemDetails>,
  UserInfo[],
  unknown[]
>;

type UseUsersOptions = Omit<UseUsersQuery, "queryKey" | "queryFn">;

export const useUsers = (options?: UseUsersOptions) => {
  return useQuery<
    UserInfo[],
    AxiosError<ProblemDetails>,
    UserInfo[],
    unknown[]
  >({
    queryKey: ["accounts"],
    queryFn: async () => {
      return await getUsers();
    },
    ...options,
  });
};
