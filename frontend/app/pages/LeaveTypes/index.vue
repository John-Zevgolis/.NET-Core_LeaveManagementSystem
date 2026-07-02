<template>
  <table class="w-full text-left">
    <thead>
      <tr class="border-b border-b-2 border-slate-900">
        <th class="py-3">Name</th>
        <th class="py-3">Maximum Allocation of Days</th>
        <th class="py-3"><span class="sr-only">Actions</span></th>
      </tr>
    </thead>
    <tbody>
      <tr
        class="border-b border-slate-200 py-3"
        v-for="item in leaveTypes"
        :key="item.id"
      >
        <td>{{ item.name }}</td>
        <td>{{ item.numberOfDays }}</td>
        <td class="flex justify-end items-center gap-2 py-2">
          <NuxtLink
            class="bg-slate-50 text-slate-800 font-medium leading-5 rounded-lg text-sm px-4 py-2.5 border"
            :to="`/leavetypes/edit/${item.id}`"
            >Edit</NuxtLink
          >

          <NuxtLink
            class="bg-slate-800 text-white font-medium leading-5 rounded-lg text-sm px-4 py-2.5"
            :to="`/leavetypes/${item.id}`"
            >Details</NuxtLink
          >
          <button
            class="bg-red-600 text-white font-medium leading-5 rounded-lg text-sm px-4 py-2.5"
            @click="deleteLeaveType(item.id)"
          >
            Delete
          </button>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script setup>
const config = useRuntimeConfig();

const {
  data: leaveTypes,
  error,
  pending,
  refresh,
} = await useFetch(`${config.public.apiBase}/leavetypes`);

const deleteLeaveType = async (id) => {
  try {
    await $fetch(`${config.public.apiBase}/leavetypes/${id}`, {
      method: 'DELETE',
    });
    await refresh();
  } catch (error) {
    console.log(error.data.message);
  }
};
</script>

<style lang="scss" scoped></style>
