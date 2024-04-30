import { Home } from "@/features/misc";
import { Create } from "@/features/sets";
import { Learn } from "@/features/sets/routes/Learn";
import MainLayout from "@/layouts/MainLayout";
import { FC } from "react";
import { RouterProvider, createBrowserRouter } from "react-router-dom";

const router = createBrowserRouter([
  {
    path: "/",
    element: <MainLayout />,
    children: [
      {
        index: true,
        element: <Home />,
      },
      {
        path: "learn",
        element: <Learn />,
      },
      {
        path: "create",
        element: <Create />,
      },
    ],
  },
]);

export const AppRouterProvider: FC = () => {
  return <RouterProvider router={router} />;
};
