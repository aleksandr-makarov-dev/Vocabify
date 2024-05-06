import { FC } from "react";
import NavItem from "./NavItem";

interface NavbarProps {
  navItems: Array<{ icon: any; text: string; link: string }>;
  slot?: React.ReactNode;
}

const Navbar: FC<NavbarProps> = ({ navItems, slot }) => {
  return (
    <nav className="fixed md:static bottom-0 w-full bg-white shadow-sm h-16 flex justify-center border-t border-boder">
      <div className="px-5 py-2.5 flex items-center justify-center md:justify-start gap-x-10 w-full max-w-screen-xl">
        <div className="hidden md:block">
          <p className="text-lg font-medium">Vocabify</p>
        </div>
        <div className="flex gap-x-8 w-auto md:w-full">
          {navItems.map((item) => (
            <NavItem key={item.text} {...item} />
          ))}
        </div>
        {slot}
      </div>
    </nav>
  );
};

export default Navbar;
