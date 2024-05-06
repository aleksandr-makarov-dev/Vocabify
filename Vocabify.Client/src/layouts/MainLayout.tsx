import Footer from "@/components/containers/Footer";
import Navbar from "@/components/containers/Navbar";
import Profile from "@/features/accounts/components/Profile";
import { BookText, Github, Home, Plus } from "lucide-react";
import { FC } from "react";
import { Outlet } from "react-router-dom";

const MainLayout: FC = () => {
  return (
    <div className="min-h-screen flex flex-col bg-gray-50">
      <Navbar
        navItems={[
          { icon: <Home className="w-6 h-6" />, text: "Home", link: "/" },
          {
            icon: <BookText className="w-6 h-6" />,
            text: "Your library",
            link: "/library",
          },
          { icon: <Plus className="w-6 h-6" />, text: "New", link: "/create" },
        ]}
        slot={<Profile />}
      />
      <div className="grow max-w-screen-md w-full mx-auto py-8 px-3 sm:px-5">
        <Outlet />
      </div>
      <Footer
        text="Vocabify 2024"
        navIcons={[
          {
            icon: <Github />,
            link: "https://github.com/aleksandrmakarov-dev",
          },
        ]}
      />
    </div>
  );
};

export default MainLayout;
