import { z } from "zod";

export const termFormSchema = z.object({
  text: z.string().min(1),
  definition: z.string().min(1),
  image: z.string().nullish(),
  textTtsUrl: z.string().optional(),
  definitionTtsUrl: z.string().optional(),
  setId: z.string().min(1),
});

export const termsListFormSchema = z.object({
  terms: z.array(termFormSchema).min(1),
});
