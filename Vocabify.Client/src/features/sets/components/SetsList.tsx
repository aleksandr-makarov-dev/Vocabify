import List from "@/components/common/List";
import { FC, HTMLAttributes } from "react";
import { useSets } from "../api/getSets";
import SetCard from "./SetCard";
import { cn } from "@/lib/utils";
import { Button } from "@/components/ui/button";
import { useNavigate, useSearchParams } from "react-router-dom";
import FormAlert from "@/components/common/FormAlert";

interface SetsListPros extends HTMLAttributes<HTMLDivElement> {}

const SetsList: FC<SetsListPros> = ({ className, ...other }) => {
  const [searchParams] = useSearchParams();
  const navigate = useNavigate();

  const { data, isLoading, isError, error } = useSets({
    search: searchParams.get("search"),
  });

  return (
    <List
      className={cn("flex flex-col sm:grid sm:grid-cols-2 gap-10", className)}
      items={data}
      isLoading={isLoading}
      isError={isError}
      emptyView={
        <div className="flex flex-col items-center gap-3 py-10 text-center">
          <p className="text-lg">No sets found</p>
          <Button onClick={() => navigate("/create")}>Create</Button>
        </div>
      }
      loadingView={<p>Loading...</p>}
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
      render={(item) => <SetCard key={item.id} {...item} />}
      {...other}
    />
  );
};

export default SetsList;
