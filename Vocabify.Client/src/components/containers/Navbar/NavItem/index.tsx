import { cn } from "@/lib/utils";
import { FC } from "react";
import { NavLink } from "react-router-dom";

interface NavItemProps {
  icon: any;
  text: string;
  link: string;
}

const NavItem: FC<NavItemProps> = ({ icon, text, link }) => {
  return (
    <NavLink
      className={({ isActive }) =>
        cn("p-2.5 rounded-md hover:bg-muted md:hover:bg-inherit", {
          "bg-muted md:bg-inherit": isActive,
        })
      }
      to={link}
    >
      <span className="md:hidden">{icon}</span>
      <span className="hidden md:block">{text}</span>
    </NavLink>
  );
};

export default NavItem;
