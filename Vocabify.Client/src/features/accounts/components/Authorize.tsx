import { FC } from "react";
import { useSession } from "../providers/SessionProvider";
import { Navigate, Outlet } from "react-router-dom";

interface AuthorizeProps {
  roles?: string[];
}

const Authorize: FC<AuthorizeProps> = ({ roles }) => {
  const { user, isLoading } = useSession();

  if (isLoading) {
    return null;
  }

  if (!user) {
    return <Navigate to="/accounts/login" replace />;
  }

  if (roles && user?.roles.some((r) => roles?.includes(r))) {
    return <p>No access</p>;
  }

  return <Outlet />;
};

export default Authorize;
