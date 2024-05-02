import Footer from "@/components/containers/Footer";
import Navbar from "@/components/containers/Navbar";
import { Github } from "lucide-react";
import { FC } from "react";
import { Outlet } from "react-router-dom";

const MainLayout: FC = () => {
  return (
    <div className="min-h-screen flex flex-col bg-gray-50">
      <Navbar
        navItems={[
          { text: "Home", link: "/" },
          {
            text: "Learn",
            link: "/learn",
          },
          {
            text: "New",
            link: "/create",
          },
        ]}
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
