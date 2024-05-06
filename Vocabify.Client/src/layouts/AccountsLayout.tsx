import { Button } from "@/components/ui/button";
import { Home } from "lucide-react";
import { FC } from "react";
import { Outlet, useNavigate } from "react-router-dom";

const AccountsLayout: FC = () => {
  const navigate = useNavigate();

  return (
    <div className="min-h-screen flex flex-col bg-gray-50">
      <div className="flex justify-between p-3 sm:px-5">
        <Button
          variant="ghost"
          icon={<Home className="w-5 h-5" />}
          onClick={() => navigate("/")}
        >
          Home
        </Button>
      </div>
      <div className="grow py-8 px-3 sm:px-5 flex items-center justify-center">
        <Outlet />
      </div>
    </div>
  );
};

export default AccountsLayout;
