import List from "@/components/common/List";
import { FC, HTMLAttributes } from "react";
import { useSets } from "../api/getSets";
import SetCard from "./SetCard";
import { cn } from "@/lib/utils";
import { Button } from "@/components/ui/button";
import { useSearchParams } from "react-router-dom";

interface SetsListPros extends HTMLAttributes<HTMLDivElement> {}

const SetsList: FC<SetsListPros> = ({ className, ...other }) => {
  const [searchParams] = useSearchParams();

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
        <div>
          No sets found. <Button>Create</Button>
        </div>
      }
      loadingView={<p>Loading...</p>}
      errorView={<p>{error?.message}</p>}
      render={(item) => <SetCard key={item.id} {...item} />}
      {...other}
    />
  );
};

export default SetsList;
