import { z } from "zod";
import { termFormSchema } from "../schemas";

export type TermFormSchema = z.infer<typeof termFormSchema>;
