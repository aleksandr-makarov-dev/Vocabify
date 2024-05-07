import { FC } from "react";
import { useSession } from "../providers/SessionProvider";
import { Navigate, Outlet } from "react-router-dom";

const Anonymous: FC = () => {
  const { user } = useSession();

  if (user) {
    return <Navigate to="/library" replace />;
  }

  return <Outlet />;
};

export default Anonymous;
