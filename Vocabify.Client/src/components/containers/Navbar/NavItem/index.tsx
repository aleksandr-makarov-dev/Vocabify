import { FC } from "react";

interface NavItemProps {
  text: string;
  link: string;
}

const NavItem: FC<NavItemProps> = ({ text, link }) => {
  return (
    <a className="" href={link}>
      {text}
    </a>
  );
};

export default NavItem;
