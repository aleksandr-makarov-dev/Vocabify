import { useTerms } from "@/features/terms/api/getTerms";
import _ from "lodash";
import { useParams } from "react-router-dom";
import LoadingView from "@/components/common/LoadingView";
import FormAlert from "@/components/common/FormAlert";
import SetQuiz from "../components/SetQuiz";

const Test = () => {
  const { id } = useParams<{ id: string }>();
  const { data, isLoading, isError, error } = useTerms({ setId: id! });

  if (isLoading) {
    return <LoadingView />;
  }

  if (isError) {
    return <FormAlert isError={isError} error={error.response?.data} />;
  }

  return <SetQuiz data={data} />;
};

export default Test;
