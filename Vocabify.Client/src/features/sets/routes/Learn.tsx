import Header from "@/components/common/Header";
import { FC } from "react";
import SetsList from "../components/SetsList";

export const Learn: FC = () => {
  return (
    <div className="space-y-10">
      <Header
        title="Learn study sets"
        subtitle="This is test subtitle for the page"
      />
      <SetsList />
    </div>
  );
};
