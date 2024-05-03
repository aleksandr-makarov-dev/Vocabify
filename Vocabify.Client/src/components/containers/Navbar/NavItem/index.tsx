import { FC } from "react";

interface NavItemProps {
  icon: any;
  text: string;
  link: string;
}

const NavItem: FC<NavItemProps> = ({ icon, text, link }) => {
  return (
    <a className="p-3" href={link}>
      <span className="md:hidden">{icon}</span>
      <span className="hidden md:block">{text}</span>
    </a>
  );
};

export default NavItem;
