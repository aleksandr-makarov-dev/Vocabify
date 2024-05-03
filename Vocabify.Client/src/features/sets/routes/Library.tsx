import Header from "@/components/common/Header";
import { FC } from "react";
import SetsList from "../components/SetsList";
import Search, { SearchFormSchema } from "@/components/common/Search";
import { useSearchParams } from "react-router-dom";

export const Library: FC = () => {
  const [searchParams, setSearchParams] = useSearchParams();

  const onSubmit = (values: SearchFormSchema) => {
    const params = new URLSearchParams(searchParams);
    params.set("search", values.search);
    setSearchParams(params);
  };

  const onReset = () => {
    const params = new URLSearchParams(searchParams);
    params.delete("search");
    setSearchParams(params);
  };

  return (
    <div className="space-y-10">
      <Header
        title="Learn study sets"
        subtitle="This is test subtitle for the page"
      />
      <div className="space-y-5">
        <Search
          value={searchParams.get("search") ?? undefined}
          placeholder="Finnish 101..."
          onSubmit={onSubmit}
          onReset={onReset}
        />
        <SetsList />
      </div>
    </div>
  );
};
