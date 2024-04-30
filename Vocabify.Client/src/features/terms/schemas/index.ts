import { z } from "zod";

export const termFormSchema = z.object({
  text: z.string().min(1),
  definition: z.string().min(1),
  image: z.string().optional(),
  textTtsUrl: z.string().optional(),
  definitionTtsUrl: z.string().optional(),
  setId: z.string().min(1),
});
