import { API_URL } from "@/config";
import axios from "axios";

const config = {
  baseURL: API_URL,
  headers: {
    "Content-Type": "application/json",
  },
};

const instance = axios.create(config);

export default instance;
