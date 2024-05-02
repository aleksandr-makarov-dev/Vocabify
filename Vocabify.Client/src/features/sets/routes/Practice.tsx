import AudioButton from "@/components/common/AudioButton";
import Card from "@/components/common/Card";
import { Button } from "@/components/ui/button";
import { Form } from "@/components/ui/form";
import { useTerms } from "@/features/terms/api/getTerms";
import TermSelect from "@/features/terms/components/TermSelect";
import TermSide from "@/features/terms/components/TermSide";
import { Term } from "@/features/terms/types";
import { zodResolver } from "@hookform/resolvers/zod";
import _ from "lodash";
import { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { useParams } from "react-router-dom";
import { z } from "zod";

export const practiceFormSchema = z.object({
  answer: z.string().min(1, "Choose one option"),
});

export type PracticeFormSchema = z.infer<typeof practiceFormSchema>;

type Question = {
  term: Term;
  options: { value: string; isCorrect: boolean }[];
};

const Practice = () => {
  const { id } = useParams<{ id: string }>();
  const { data, isLoading } = useTerms({ setId: id! });
  const [terms, setTerms] = useState<Term[]>();
  const [index, setIndex] = useState<number>(0);
  const [question, setQuestion] = useState<Question>();
  const [state, setState] = useState<boolean>(false);

  const form = useForm<PracticeFormSchema>({
    resolver: zodResolver(practiceFormSchema),
    defaultValues: {
      answer: "",
    },
  });

  useEffect(() => {
    if (!data) {
      return;
    }

    setTerms(_.shuffle(data));
  }, [data]);

  useEffect(() => {
    if (!terms) {
      return;
    }

    const term = terms[index];

    const newQuestion: Question = {
      term: term,
      options: _.shuffle([
        ..._.shuffle(terms)
          .filter((t) => t.id !== term.id)
          .slice(0, 3)
          .map((t) => ({ value: t.text, isCorrect: false })),
        { value: term.text, isCorrect: true },
      ]),
    };

    setQuestion(newQuestion);
  }, [index, terms]);

  const onSubmit = (values: PracticeFormSchema) => {
    setState(true);

    if (values.answer === question?.term.text) {
      form.reset();
      setState(false);
      setIndex((prev) => prev + 1);
    }
  };

  if (isLoading) {
    return <p>Loading...</p>;
  }

  if (!question) {
    return null;
  }

  return (
    <Card className="space-y-5 p-5">
      <div className="flex items-center gap-3">
        <p className="font-medium text-muted-foreground">Definition</p>
        <AudioButton
          queue={[`https://quizlet.com/${question.term.definitionTtsUrl}`]}
        />
      </div>
      <TermSide text={question.term.definition} image={question.term.image} />
      <Form {...form}>
        <form className="space-y-5" onSubmit={form.handleSubmit(onSubmit)}>
          <TermSelect
            control={form.control}
            options={question.options}
            state={state}
          />
          <div className="text-end space-x-3  ">
            <Button variant="ghost">Don't know?</Button>
            <Button>Answer</Button>
          </div>
        </form>
      </Form>
    </Card>
  );
};

export default Practice;
