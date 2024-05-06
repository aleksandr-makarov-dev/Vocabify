import { Button } from "@/components/ui/button";
import { LogOut, User } from "lucide-react";
import { FC } from "react";
import { useSession } from "../providers/SessionProvider";
import { useMediaQuery } from "usehooks-ts";
import { useLogout } from "../api/logout";
import { useNavigate } from "react-router-dom";

const Profile: FC = () => {
  const { user, isLoading, logout } = useSession();
  const { mutate } = useLogout();
  const matches = useMediaQuery("(max-width: 768px)");
  const navigate = useNavigate();

  const onLogout = () => {
    mutate(
      {},
      {
        onSuccess: () => logout(),
      }
    );
  };

  if (user) {
    return (
      <Button
        size={matches ? "icon" : "default"}
        icon={<LogOut className="w-5 h-5" />}
        onClick={onLogout}
      >
        {matches ? null : "Log out"}
      </Button>
    );
  }

  return (
    <Button
      size={matches ? "icon" : "default"}
      icon={<User className="w-5 h-5" />}
      loading={isLoading}
      onClick={() => navigate("/accounts/login")}
    >
      {matches ? null : "Log in"}
    </Button>
  );
};

export default Profile;
