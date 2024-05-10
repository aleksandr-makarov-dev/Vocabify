import Header from "@/components/common/Header";
import { FC, useState } from "react";
import SetForm from "../components/SetForm";
import { SetFormSchema, SetImportFormSchema, SetWithTerms } from "../types";
import { useCreateSet } from "../api/createSet";
import SetImportForm from "../components/SetImportForm";
import { useImportSet } from "../api/importSet";
import { useCreateTerms } from "@/features/terms/api/сreateTerms";
import { TermFormSchema } from "@/features/terms/types";
import { useNavigate } from "react-router-dom";
import FormAlert from "@/components/common/FormAlert";

export const Create: FC = () => {
  const navigate = useNavigate();
  const [importedSet, setImportedSet] = useState<SetWithTerms | undefined>(
    undefined
  );

  const { mutate, isPending, isError, error } = useImportSet();

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

  const onImport = (values: SetImportFormSchema) => {
    mutate(values, {
      onSuccess: (values) => {
        setImportedSet(values);
      },
    });
  };

  return (
    <div className="space-y-5">
      <Header
        title="Create new study set"
        subtitle="This is test subtitle for the page"
      />
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
      <SetImportForm onSubmit={onImport} isLoading={isPending} />
      <FormAlert
        isError={isCreateSetError || isCreateTermsError}
        error={
          createSetError?.response?.data || createTermsError?.response?.data
        }
      />
      <SetForm
        onSubmit={onSubmit}
        isLoading={isCreateSetLoading || isCreateTermsLoading}
        set={importedSet}
      />
    </div>
  );
};
