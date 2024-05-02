import axios from "axios";

const config = {
  baseURL: "http://localhost:8080/api",
  headers: {
    "Content-Type": "application/json",
  },
};

const instance = axios.create(config);

export default instance;
