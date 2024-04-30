import { FC } from "react";
import NavItem from "./NavItem";

interface NavbarProps {
  navItems: Array<{ text: string; link: string }>;
}

const Navbar: FC<NavbarProps> = ({ navItems }) => {
  return (
    <nav className="bg-white shadow-sm">
      <div className="px-5 py-2.5 flex items-center gap-x-10 max-w-screen-2xl mx-auto">
        <div>
          <p className="text-lg font-medium">Vocabify</p>
        </div>
        <div className="space-x-8 w-full">
          {navItems.map((item) => (
            <NavItem key={item.text} {...item} />
          ))}
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
