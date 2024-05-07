import Header from "@/components/common/Header";
import { FC, useState } from "react";
import SetForm from "../components/SetForm";
import { SetFormSchema, SetImportSchema } from "../types";
import { useCreateSet } from "../api/createSet";
import SetImportForm from "../components/SetImportForm";
import { useImportSet } from "../api/importSet";
import { useCreateTerms } from "@/features/terms/api/сreateTerms";
import { TermFormSchema } from "@/features/terms/types";
import { useNavigate } from "react-router-dom";

export const Create: FC = () => {
  const navigate = useNavigate();
  const [url, setUrl] = useState<string>("");

  const { data, isLoading } = useImportSet(
    {
      url: url,
    },
    {
      enabled: !!url && url.length > 0,
    }
  );

  const {
    mutate: createSetMutate,
    isPending: isCreateSetLoading,
    isError: isCreateSetError,
    error: createSetError,
  } = useCreateSet();
  const {
    mutate: createTermsMutate,
    isPending: isCreateTermsLoading,
    isError: isCreateTermsError,
    error: createTermsError,
  } = useCreateTerms();

  const onSubmit = ({
    title,
    description,
    image,
    textLang,
    definitionLang,
    terms,
  }: SetFormSchema) => {
    createSetMutate(
      { title, description, image, textLang, definitionLang },
      {
        onSuccess: ({ id }) => {
          createTermsMutate(
            {
              terms: terms.map(
                (term): TermFormSchema => ({ ...term, setId: id })
              ),
            },
            {
              onSuccess: () => {
                navigate(`/${id}`);
              },
            }
          );
        },
      }
    );
  };

  const onImport = (values: SetImportSchema) => {
    setUrl(values.url);
  };

  return (
    <div className="space-y-5">
      <Header
        title="Create new study set"
        subtitle="This is test subtitle for the page"
      />
      <SetImportForm onSubmit={onImport} isLoading={isLoading} />
      <SetForm
        onSubmit={onSubmit}
        isLoading={isCreateSetLoading || isCreateTermsLoading}
        set={data}
      />
    </div>
  );
};
