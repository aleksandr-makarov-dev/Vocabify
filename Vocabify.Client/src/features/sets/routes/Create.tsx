import Header from "@/components/common/Header";
import { FC } from "react";
import SetForm from "../components/SetForm";
import { SetFormSchema } from "../types";
import TermForm from "@/features/terms/components/TermForm";
import Card from "@/components/common/Card";

export const Create: FC = () => {
  return (
    <div className="space-y-5">
      <Header
        title="Create new study set"
        subtitle="This is test subtitle for the page"
      />
      <SetForm onSubmit={(set: SetFormSchema) => {}} />
      <Card>
        <TermForm onSubmit={() => {}} />
      </Card>
    </div>
  );
};
