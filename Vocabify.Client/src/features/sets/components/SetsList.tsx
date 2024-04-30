import List from "@/components/common/List";
import { FC, HTMLAttributes } from "react";
import { useSets } from "../api/getSets";
import SetCard from "./SetCard";
import { cn } from "@/lib/utils";

interface SetsListPros extends HTMLAttributes<HTMLDivElement> {}

const SetsList: FC<SetsListPros> = ({ className, ...other }) => {
  const { data, isLoading, isError } = useSets();

  return (
    <List
      className={cn("flex flex-col sm:grid sm:grid-cols-2 gap-10", className)}
      items={data}
      isLoading={isLoading}
      isError={isError}
      render={(item) => <SetCard key={item.id} {...item} />}
      {...other}
    />
  );
};

export default SetsList;
