import { z } from "zod";
import { confirmEmailSchema, loginSchema, registerSchema } from "../schemas";

export type RegisterSchema = z.infer<typeof registerSchema>;

export type LoginSchema = z.infer<typeof loginSchema>;

export type ConfirmEmailSchema = z.infer<typeof confirmEmailSchema>;

export type UserInfo = {
  email: string;
  roles: string[];
};
