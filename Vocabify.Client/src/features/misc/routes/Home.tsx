import Header from "@/components/common/Header";
import { FC } from "react";

export const Home: FC = () => {
  return (
    <div className="space-y-5">
      <Header title="What is Vocabify?" />
      <p>
        A language learing project built using ASP.NET Web API, EntityFramework
        and Identity, React, SQLite and hosted using Docker.
      </p>
      <div>
        <h5 className="text-lg font-medium mb-1.5">Implemented features</h5>
        <ul className="pl-3 list-disc list-inside">
          <li>Webpage parsing</li>
          <li>Test generation</li>
          <li>Data stores in the database</li>
          <li>Cookie based authentication and authorization</li>
        </ul>
      </div>
    </div>
  );
};
