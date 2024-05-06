import { z } from "zod";
import { loginSchema, registerSchema } from "../schemas";

export type RegisterSchema = z.infer<typeof registerSchema>;

export type LoginSchema = z.infer<typeof loginSchema>;

export type UserInfo = {
  email: string;
  roles: string[];
};
