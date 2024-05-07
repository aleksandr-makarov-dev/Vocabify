import { FC } from "react";
import { ConfirmEmailSchema, UserInfo } from "../types";
import Card from "@/components/common/Card";
import { useConfirmEmail } from "../api/confirmEmail";
import { useQueryClient } from "@tanstack/react-query";
import ConfirmEmailForm from "./ConfirmEmailForm";

interface UserCardProps {
  user: UserInfo;
}

const UserCard: FC<UserCardProps> = ({ user }) => {
  const { mutate, isPending } = useConfirmEmail();
  const queryClient = useQueryClient();

  const onSubmit = (values: ConfirmEmailSchema) => {
    mutate(values, {
      onSuccess: () => {
        queryClient.setQueryData<UserInfo[]>(["accounts"], (prev) =>
          prev?.filter((item) => item.email !== values.email)
        );
      },
    });
  };

  return (
    <Card>
      <ConfirmEmailForm user={user} onSubmit={onSubmit} isLoading={isPending} />
    </Card>
  );
};

export default UserCard;
