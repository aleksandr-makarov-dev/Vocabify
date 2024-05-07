import { FC, PropsWithChildren, createContext, useContext } from "react";
import { useUserInfo } from "../api/getUserInfo";
import { useQueryClient } from "@tanstack/react-query";

type UserInfo = {
  email: string;
  roles: string[];
};

type SessionContextData = {
  user?: UserInfo;
  isLoading?: boolean;
  logout: () => void;
  login: () => void;
};

const SessionContext = createContext<SessionContextData | undefined>(undefined);

const SessionProvider: FC<PropsWithChildren> = ({ children }) => {
  const queryClient = useQueryClient();
  const { data, isFetching, isLoading, isRefetching } = useUserInfo();

  const login = () => {
    queryClient.invalidateQueries({ queryKey: ["accounts", "info"] });
  };

  const logout = () => {
    queryClient.resetQueries({ queryKey: ["accounts", "info"] });
  };

  return (
    <SessionContext.Provider
      value={{
        user: data,
        isLoading: isFetching || isLoading || isRefetching,
        login: login,
        logout: logout,
      }}
    >
      {children}
    </SessionContext.Provider>
  );
};

export default SessionProvider;

export const useSession = () => {
  const context = useContext<SessionContextData | undefined>(SessionContext);

  if (!context) {
    throw new Error("useSession should be used within <SessionContext>");
  }

  return context;
};
