import { z } from "zod";
import { setFormSchema } from "../schemas";
import { TermFormSchema } from "@/features/terms/types";

export type Set = {
  id: string;
  title: string;
  description: string;
  image?: string;
  url?: string;
  textLang: string;
  definitionLang: string;
};

export type SetWithTerms = {
  title: string;
  description: string;
  image?: string;
  textLang: string;
  definitionLang: string;
  terms: TermFormSchema[];
};

export type SetFormSchema = z.infer<typeof setFormSchema>;

export type CreateSetSchema = Omit<SetFormSchema, "terms">;
