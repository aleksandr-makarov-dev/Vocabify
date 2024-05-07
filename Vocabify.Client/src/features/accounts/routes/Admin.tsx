import { FC } from "react";
import { useUsers } from "../api/getUsers";
import List from "@/components/common/List";
import UserCard from "../components/UserCard";
import FormAlert from "@/components/common/FormAlert";
import Header from "@/components/common/Header";
import LoadingView from "@/components/common/LoadingView";
import UsersEmptyView from "../components/UsersEmptyView";

export const Admin: FC = () => {
  const { data, isLoading, isError, error } = useUsers();

  return (
    <div className="space-y-5">
      <Header title="Admin panel" subtitle="Manage access to the website" />
      <List
        className="flex flex-col"
        items={data}
        isLoading={isLoading}
        loadingView={<LoadingView subtitle="Loading users..." />}
        emptyView={<UsersEmptyView />}
        isError={isError}
        errorView={
          <FormAlert
            isError={isError}
            error={
              error?.response?.data ?? {
                title: "Error",
                status: 0,
                detail: error?.message,
              }
            }
          />
        }
        render={(item) => <UserCard key={item.email} user={item} />}
      />
    </div>
  );
};
