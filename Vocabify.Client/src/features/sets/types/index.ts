import { z } from "zod";
import { setFormSchema } from "../schemas";

export type Set = {
  id: string;
  title: string;
  description: string;
  image: string | null;
  url: string | null;
  textLang: string;
  definitionLang: string;
  itemsCount: number;
};

export type SetFormSchema = z.infer<typeof setFormSchema>;
