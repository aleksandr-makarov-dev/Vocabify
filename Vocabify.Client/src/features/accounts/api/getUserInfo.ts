import { ProblemDetails } from "@/types";
import axios from "@/lib/axios";
import { AxiosError } from "axios";
import { UseQueryOptions, useQuery } from "@tanstack/react-query";
import { UserInfo } from "../types";

const getUserInfo = async (): Promise<UserInfo> => {
  const response = await axios.get<UserInfo>("/accounts/info");
  return response.data;
};

type UseUserInfoQuery = UseQueryOptions<
  UserInfo,
  AxiosError<ProblemDetails>,
  UserInfo,
  unknown[]
>;

type UseUserInfoOptions = Omit<UseUserInfoQuery, "queryKey" | "queryFn">;

export const useUserInfo = (options?: UseUserInfoOptions) => {
  return useQuery<UserInfo, AxiosError<ProblemDetails>, UserInfo, unknown[]>({
    queryKey: ["accounts", "info"],
    queryFn: async () => {
      return await getUserInfo();
    },
    ...options,
  });
};
