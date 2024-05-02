import { termFormSchema } from "@/features/terms/schemas";
import { z } from "zod";

export const setFormSchema = z.object({
  title: z.string().min(5),
  description: z.string().optional(),
  image: z.string().optional(),
  textLang: z.string().length(2),
  definitionLang: z.string().length(2),
  terms: z.array(termFormSchema).min(2, "Must import at least 2 items"),
});
